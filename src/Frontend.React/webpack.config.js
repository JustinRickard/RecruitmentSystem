module.exports = {
    entry: {
        participant: "./src/participantApp/index.js",
        admin: "./src/adminApp/index.js",
    },
    output: {
        path: __dirname + "/dist",
        filename: "[name]-bundle.js"
    },
    resolve: {
        extensions: ['.js', '.jsx']
    },
    module: {
        loaders: [
            {
                test: /\.jsx?$/,
                loader: 'babel-loader',
                exclude: /node_modules/,
                query: {
                    cacheDirectory: true,
                    presets: ['react', 'es2015']
                }
            }
        ]
    },
    devServer: {
        publicPath: "./",
        contentBase: "./",
        hot: true
    },
};

function isExternal(module) {
  var userRequest = module.userRequest;

  if (typeof userRequest !== 'string') {
    return false;
  }

  return userRequest.indexOf('bower_components') >= 0 ||
         userRequest.indexOf('node_modules') >= 0 ||
         userRequest.indexOf('libraries') >= 0;
}