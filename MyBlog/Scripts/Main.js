//loading the DOM into jQuery
$(document).ready(function () {
    //here is where we put our code
    // selecthing anything with the class of likes
    // when it is clicked run the function
    
    $('.likes').on('click', function () {
        var id = $(this).data('id');
        
        // put our likes div into a varible
        var likesDiv = $(this);
        $.get('/Home/Like/' + id, function (data)
        {
            //repalce the hmtl of the like dive that was clicked, with the string
            //string returned form our get
           likesDiv.html(data);
        });
    });
    // add a comment
    $('.addComment form').on('submit', function (event) {
        
        // stop the form submitting normally
        event.preventDefault();
        var theForm = $(this);
        //put this (theform) into a varible
        //
        // do the ajax post, use the serialize
        $.post('/home/addComment', $(this).serialize(), function (data) {
            theForm.parent().prepend(data);


        });
            
        });
});