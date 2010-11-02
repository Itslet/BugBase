$(document).ready(function () {
    $('#BugSubmitform').ajaxForm({
        dataType: 'json',
        success: function (response) {
            $('h6').text("Bugname: " + response.Name + ".  And the description is: " + response.Description);
            alert(response.Description);
        }
    });
});