export default {
    "ProjectTable": {
        "UpdateID": "PUpdate",
        "SearchID": "searchbar",
        "BoxID": "TableList", //<tr><td class= "column1" ><div class="scrollable ScrollLook">%Headline%</div></td><td class="column2"><div class="scrollable ScrollLook">%Description%</div></td><td class="column3"><div class="scrollable ScrollLook">%Documentation%</div></td><td class="column4"><div class="scrollable ScrollLook">%Students%</div></td></tr>
        "BoxErrorElement": "<h6 style=\"color: red; text-align: center;\">%Error%</h6>",
        "BoxLoadingElement": "<img src=\"Style/Image/loadingIcon.png\" class=\"loading\" alt=\"Loading ...\" /><h6 style=\"text-align: center;\"> Loading ... </h6>",
        "BoxTableDataElement": "<tr><td class=\"column1\"><div class=\"scrollable ScrollLook\"><a href=\"Project.aspx?projectid=%ID%\">%Headline%</a></div></td><td class=\"column2\"><div class=\"scrollable ScrollLook\">%Description%</div></td><td class=\"column3\"><div class=\"scrollable ScrollLook\">%Documentation%</div></td><td class=\"column4\"><div class=\"scrollable ScrollLook\">%Students%</div></td></tr>"
    },
    "StudentTable": {
        "UpdateID": "PUpdate",
        "SearchID": "searchbar",
        "BoxID": "TableList",
        "BoxErrorElement": "<h6 style=\"color: red; text-align: center;\">%Error%</h6>",
        "BoxLoadingElement": "<img src=\"Style/Image/loadingIcon.png\" class=\"loading\" alt=\"Loading ...\" /><h6 style=\"text-align: center;\"> Loading ... </h6>",
        "BoxTableDataElement": "<article class=\"TableBody row\"><a href=\"Student.aspx?username=%Username%\" class=\"col-md-3\"><header class=\"ScrollLook\">%Name%</header></a><header class=\"col-md-6 ScrollLook\">%Projects%</header><header class=\"col-md-3 ScrollLook\">%Education%</header></article>"
    }
}