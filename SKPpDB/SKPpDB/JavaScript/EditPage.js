var HeadlineText = document.getElementById("ContentPlaceHolder1_HeadlineText");
var DescriptionText = document.getElementById("ContentPlaceHolder1_DescriptionText");
var DocumentationText = document.getElementById("ContentPlaceHolder1_DocumentationText");

window.addEventListener('load', function () {

    FillInput();
})
async function FillInput() {
    var params = getParams(window.location.href);
    var Project = await FetchJson("https://localhost:44369/api/project?projectid=" + params['projectid']);
    
    console.log(Project);
    HeadlineText.value = Project["Headline"];
    DescriptionText.value = Project["Description"];
    DocumentationText.value = Project["Documentation"];
}



var getParams = function (url) {
    var params = {};
    var parser = document.createElement('a');
    parser.href = url;
    var query = parser.search.substring(1);
    var vars = query.split('&');
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split('=');
        params[pair[0]] = decodeURIComponent(pair[1]);
    }
    return params;
};