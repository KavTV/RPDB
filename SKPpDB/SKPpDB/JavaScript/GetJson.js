function FetchJson(Url) {

    try {
        var data = $.getJSON(Url);
        return data;
    }
    catch {
        return null;
    }
}