function imageClick(url) {
    window.location = url;
}

function redirectOnClick(data) {
    document.location = 'TicketBooking/GenerateBill(data)';
}

function updateTextArea() {

    //if ($("input:checked").length == ($("#Numseats").val())) {
    //    $(".seatStructure *").prop("disabled", true);

    //var allNameVals = [];
    //var allNumberVals = [];
    var allSeatsVals = [];

    //Storing in Array
    //allNameVals.push($("#Username").val());
    //allNumberVals.push($("#Numseats").val());
    $('#seatsBlock :checked').each(function () {
        allSeatsVals.push($(this).val());        
        });

    //Displaying
    //$('#nameDisplay').val(allNameVals);
    //$('#NumberDisplay').val(allNumberVals);
    $('#seatsDisplay').val(allSeatsVals);
    //} else {
    //    alert("Please select " + ($("#Numseats").val()) + " seats")
    //}
}


function myFunction() {
    alert($("input:checked").length);
}

$(":checkbox").click(function () {
    //if ($("input:checked").length == ($("#Numseats").val())) {
    $(":checkbox").prop('disabled', true);    //For single selection
    $(':checked').prop('disabled', false);  //For multiple selection
    //} else {
    //    $(":checkbox").prop('disabled', false);
    //}
});


        window.onload = function AlertMessage () {
            alert("@ViewBag.Msg");
            window.location.href = '/Home/HomePage';
        };
