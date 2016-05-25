/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    var babelConfig = {
        files:{
            src: "scripts/es6/**/*js",
            dest:"scripts/es5/scripts.js"
        }
    }

    grunt.initConfig({
        babel:babelConfig
    });

    grunt.loadNpmTasks('grunt-babel');
};