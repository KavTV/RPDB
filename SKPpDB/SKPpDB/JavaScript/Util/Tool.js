export var getParams = function (url) {
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

export var SimpleDate = function (Date) {
    return `${("0" + Date.getDate()).slice(-2)}-${("0" + (Date.getMonth() + 1)).slice(-2)}-${Date.getFullYear()}`;
};