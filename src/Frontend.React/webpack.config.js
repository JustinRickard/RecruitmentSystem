module.exports = {
    entry: {
        participant: "./src/participantApp/index.js",
        admin: "./src/adminApp/index.js",
    },
    output: {
        path: __dirname + "/dist",
        filename: "[name]-bundle.js"
    }
};