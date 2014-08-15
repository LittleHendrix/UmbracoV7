(function($) {

    //$('#contactForm').submit(function (e) {
    //    console.log('aha');
    //    var actionPath = '@Url.Action("ContactUsJson", "ContactSurfaceController")';
    //    var formData = {
    //        'Name': $('#Name').val(),
    //        'EmailAddress': $('#EmailAddress').val(),
    //        'Subject': $('#Subject').val(),
    //        'Message': $('#Message').val(),
    //        'Captcha': $('#Captcha').val(),
    //        'SubmiteDate': $('#SubmitDate').val()
    //    }

    //    $.ajax({
    //        type: 'POST',
    //        url: actionPath,
    //        data: formData,
    //        dataTpe: 'json',
    //        success: function (data) {
    //            console.log(data);
    //        },
    //        error: function (jqXHR, textStatus, error) {
    //            console.log(jqXHR);
    //            console.log(textStatus);
    //            console.log(error);
    //        }
    //    });

    //    e.preventDefault();


    //});

    initTypeAhead();

})(jQuery);


function initTypeAhead() {
    var results = {};
    $('.typeahead').typeahead({
        minLength: 3,
        items: 20,
        source: function (query, process) {
            $.post('/search?json=true&searchTerms=' + query, { q: query, limit: 8 }, function (data) {
                titles = [];
                results = {};
                $.each(data, function (i, result) {
                    results[result.Title] = result;
                    titles.push(result.Title);
                });
                process(titles);
            });
        },
        matcher: function (item) { return true; },
        updater: function (item) {
            var selectedValue = '';
            if (item == undefined) {
                selectedValue = $('.typeahead').val();
                $('.typeahead').closest('form').submit();
            }
            else {
                selectedValue = item;
                window.location = results[item].Url;
            }
            return $('.typeahead').val();
        }
    });
}