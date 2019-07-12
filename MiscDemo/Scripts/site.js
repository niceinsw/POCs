var myArray = [1,2, 3, 5, 7];

$(document).ready(function () {
    console.log("tdxt");
    
    
    //if (new RegExp("([a-zA-Z0-9]+://)?([a-zA-Z0-9_]+:[a-zA-Z0-9_]+@)?([a-zA-Z0-9.-]+\\.[A-Za-z]{2,4})(:[0-9]+)?(/.*)?").test(txt)) {
    //    alert("url inside");
    //}

    $("#btnCheck").click(function () {
        var txt = $('textarea#commentArea').val();

        console.log(txt);

        var res = new RegExp("([a-zA-Z0-9]+://)?([a-zA-Z0-9_]+:[a-zA-Z0-9_]+@)?([a-zA-Z0-9.-]+\\.[A-Za-z]{2,4})(:[0-9]+)?(/.*)?").test(txt);
        console.log(res);
        if (res == true) {
            $("#result").html("Comment has URL");
        } else {
            $("#result").html("No URL found in comments");
        }
    });

});