//search though all HTML webpages
var fs = require('fs');

fs.readdir('/path/to/html/files', function (err, files) {
    files
         .filter(function (file) { return file.substr(-5) === '.html'; })
         .forEach(function (file) { fs.readFile(file, 'utf-8', function (err, contents) { inspectFile(contents); }); });
});

function inspectFile(contents) {
    if (contents.indexOf('data-template="home"') != -1) {
        // do something
    }
}


//search for specific elements


$('.product-name h1').each(function() {

});

$('.product-name .skuMPUS').each(function () {

});


$('.product-name .short-description .std').each(function () {

});

