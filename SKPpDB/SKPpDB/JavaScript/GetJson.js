function FetchJson(Url) {

    try {
        var data = $.getJSON(Url);
        return data;
    }
    catch {
        return null;
    }
}

function PostData(Url) {
    try {
        fetch(Url, {method: 'POST'});
    }
    catch {
        return null
    }
}