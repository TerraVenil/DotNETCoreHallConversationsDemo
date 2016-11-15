var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require("extract-text-webpack-plugin");
var FailPlugin = require('webpack-fail-plugin');

var webpackConfigs = {
    devServer: {
        contentBase: 'wwwroot/',
        inline: true,
        progress: true,
        hot: true,
        proxy: {
            "**": {
                target: 'http://localhost:5000',
            }
        }
    },
    entry: {
        app: [
            "./app/boot-client.ts",
            "./app/components/app/app.component.css"
        ],
        'node-modules': [
            '@angular/common',
            '@angular/compiler',
            '@angular/core',
            '@angular/forms',
            '@angular/http',
            '@angular/platform-browser',
            '@angular/platform-browser-dynamic',
            '@angular/router',
            'core-js',
            'zone.js',
            'bootstrap',
            'bootstrap/dist/css/bootstrap.css',
            'jquery',
            'ng2-datetime/src/vendor/bootstrap-datepicker/bootstrap-datepicker.min.js',
            'ng2-datetime/src/vendor/bootstrap-datepicker/bootstrap-datepicker3.min.css'
        ]
    },
    output: {
        path: __dirname + "/wwwroot/assets",
        filename: "js/[name].bundle.js",
        publicPath: "/assets/"
    },
    plugins: [
        // Enable HMR from FE side
        /*new webpack.HotModuleReplacementPlugin(),*/
        new HtmlWebpackPlugin({
            title: "Remont Online",
            template: "index.ejs", 
            filename: "../index.html"
        }),
        new webpack.optimize.CommonsChunkPlugin('node-modules', 'js/[name].bundle.js'),
        new ExtractTextPlugin("css/[name].css"),
        new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' }),
        FailPlugin
    ],
    resolve: {
        extensions: [ '', '.ts', '.js' ]
    },
    devtool: 'source-map',
    module: {
         loaders: [
             { test: /src.*\.js$/, loaders: [ 'ng-annotate' ] },
             { test: /\.ts$/, loader: 'ts-loader' },
             { test: /\.html$/, loader: 'raw' },
             { test: /\.css$/, loaders: [ 'to-string-loader', ExtractTextPlugin.extract("style-loader", "css-loader") ] },
             { test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/, loader: 'url-loader?limit=100000&name=static/[ext]/[name].[ext]' }
         ]
     }
};

module.exports = webpackConfigs;