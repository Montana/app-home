﻿/// <binding Clean='clean' ProjectOpened='watch' />

var gulp = require("gulp"),
	sass = require("gulp-sass"),
	watch = require("gulp-watch"),
	rimraf = require("rimraf"),
	fs = require("fs");

eval("var project = " + fs.readFileSync("./project.json"));

var paths = {
	bower: "./bower_components/",
	lib: "./" + project.webroot + "/lib/"
};

gulp.task("clean", function (cb) {
	rimraf(paths.lib, cb);
});

gulp.task('watch', function () {
	gulp.watch('./Assets/scss/**/*.scss', ['sass']);
});

gulp.task('sass', function () {
	gulp.src('./Assets/scss/*.scss')
		.pipe(sass())
		.pipe(gulp.dest(project.webroot + '/css'));
});

gulp.task("copy", ["clean"], function () {
	var bower = {
		"bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
		"jquery": "jquery/jquery*.{js,map}",
		"jquery-validation": "jquery-validation/jquery.validate.js",
		"jquery-validation-unobtrusive": "jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
		"particles.js": "**/particles.js"
	}

	for (var destinationDir in bower) {
		gulp.src(paths.bower + bower[destinationDir])
		  .pipe(gulp.dest(paths.lib + destinationDir));
	}
});
