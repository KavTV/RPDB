﻿export default {
    "ProjectTable": {
        "UpdateID": "PUpdate",
        "SearchID": "searchbar",
        "BoxID": "TableList",
        "BoxErrorElement": "<h6 style=\"color: red; text-align: center;\">%Error%</h6>",
        "BoxLoadingElement": "<img src=\"Style/Image/loadingIcon.png\" class=\"loading\" alt=\"Loading ...\" /><h6 style=\"text-align: center;\"> Loading ... </h6>",
        "BoxTableDataElement": "<article class=\"TableBody row\"><a href=\"Project.aspx?projectid=%ID%\" class=\"col-md-2\"><header class=\"ScrollLook\">%Headline%</header></a><header class=\"col-md-6 ScrollLook\">%Description%</header><header class=\"col-md-2 ScrollLook\">%Documentation%</header><header class=\"col-md-2 ScrollLook\">%Students%</header></article\">"
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