var Apisite = "https://api.skprgopg.zbc.dk/";
console.log("module test");

function FetchJson(Url) {
    try {
        var data = $.getJSON(Apisite + Url);
        return data;
    }
    catch {
        return 403;
    }
}

function PostData(Url) {
    try {
        return $.post(Apisite + Url);
    }
    catch {
        return 403;
    }
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

function MenuBoxWidth(Width) {
    document.getElementById("MenuBox").style.width = Width;
}

function LoadingScreen(onOrOff) {
    if (onOrOff) {
        document.getElementById("loading").style.display = "block";
    }
    else {
        document.getElementById("loading").style.display = "none";
    }
}

function MainError() {
    LoadingScreen(false);
    document.getElementById("Mainbox").innerHTML = "<h4 style='color: red; text-align:center;'>Kunne ikke oprette forbinelse til service<br>Prøv igen senere</h4>";
}