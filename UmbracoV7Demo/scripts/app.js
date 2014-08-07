(function($) {

    $('#contactForm').submit(function (e) {
        console.log('aha');
        var actionPath = '@Url.Action("ContactUsJson", "ContactSurfaceController")';
        var formData = {
            'Name': $('#Name').val(),
            'EmailAddress': $('#EmailAddress').val(),
            'Subject': $('#Subject').val(),
            'Message': $('#Message').val(),
            'Captcha': $('#Captcha').val(),
            'SubmiteDate': $('#SubmitDate').val()
        }

        $.ajax({
            type: 'POST',
            url: actionPath,
            data: formData,
            dataTpe: 'json',
            success: function (data) {
                console.log(data);
            },
            error: function (jqXHR, textStatus, error) {
                console.log(jqXHR);
                console.log(textStatus);
                console.log(error);
            }
        });

        e.preventDefault();


    });


})(jQuery);