
var ajaxForm = document.getElementById('ajaxForm');
var ajaxStatus = document.getElementById('ajaxStatus');

function onBegin(data) {
    ajaxStatus.innerHTML = "<h3>Begining Ajax request.</h3>";
    console.log(data);
}

function onComplete(data) {
    ajaxStatus.innerHTML = "<h3>Completing Ajax request.</h3>";
    console.log(data);
}

function onSuccess(data) {
    ajaxStatus.className += "alert alert-success";
    ajaxStatus.innerHTML = "<h3>Ajax request successful.</h3>";
    console.log(data);
}

function onFailure(data) {
    ajaxStatus.className += "alert alert-error";
    ajaxStatus.innerHTML = "<p><strong>Error!</strong> There was an error posting the form.</p>";
    console.log(data);
}