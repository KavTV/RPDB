export default {
    "ProjectTable": {
        "UpdateID": "PUpdate",
        "SearchID": "searchbar",
        "BoxID": "TableList", //<tr><td class= "column1" ><div class="scrollable ScrollLook">%Headline%</div></td><td class="column2"><div class="scrollable ScrollLook">%Description%</div></td><td class="column3"><div class="scrollable ScrollLook">%Documentation%</div></td><td class="column4"><div class="scrollable ScrollLook">%Students%</div></td></tr>
        "BoxErrorElement": "<h6 style=\"font-size: 24px; color: red; text-align: center;\">Hov der var en fejl.<br>Har du husket at acceptere data'en <br><a href=\"https://api.skprgopg.zbc.dk\">https://api.skprgopg.zbc.dk</a></h6>",
        "BoxLoadingElement": "<img src=\"Style/Image/loadingIcon.png\" class=\"loading\" alt=\"Loading ...\" /><h6 style=\"text-align: center;\"> Loading ... </h6>",
        "BoxTableDataElement": "<tr><td class=\"column1 columnStart\"><div class=\"scrollable ScrollLook\"><a href=\"Project.aspx?projectid=%ID%\">%Headline%</a></div></td><td class=\"column2\"><div class=\"scrollable ScrollLook\">%Description%</div></td><td class=\"column3\"><div class=\"scrollable ScrollLook\">%Documentation%</div></td><td class=\"column4 columnEnd\"><div class=\"scrollable ScrollLook\">%Students%</div></td></tr>"
    },
    "StudentTable": {
        "UpdateID": "PUpdate",
        "SearchID": "searchbar",
        "BoxID": "TableList",
        "BoxErrorElement": "<h6 style=\"font-size: 24px; color: red; text-align: center;\"><br><a href=\"https://api.skprgopg.zbc.dk\">https://api.skprgopg.zbc.dk</a></h6>",
        "BoxLoadingElement": "<img src=\"Style/Image/loadingIcon.png\" class=\"loading\" alt=\"Loading ...\" /><h6 style=\"text-align: center;\"> Loading ... </h6>",
        "BoxTableDataElement": "<tr><td class=\"column1 columnStart\"><div class=\"scrollable ScrollLook\"><a href=\"Student.aspx?username=%Username%\">%Name%</a></div></td><td class=\"column3\"><div class=\"scrollable ScrollLook\">%Education%</div></td><td class=\"column2 columnEnd\"><div class=\"scrollable ScrollLook\">%Projects%</div></td></tr>"
    }
}