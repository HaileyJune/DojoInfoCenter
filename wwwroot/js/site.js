// Write your Javascript code.

//appends an "active" class to .popup and .popup-content when the "Open" button is clicked
$(".open").on("click", function(){
    $(".popup-overlay, .popup-content").addClass("active");
    
});

//removes the "active" class to .popup and .popup-content when the "Close" button is clicked 
$(".close").on("click", function(){
    $(".popup-overlay, .popup-content").removeClass("active");
});


$(".Room").on("click", function(){
    var roomName = $(this).attr("data-room")
    // console.log(roomName);
    // return false
    $.ajax({
        url : `/${roomName}`,
        method: "get",
    }).done(function (response){
        $(".popup-content").html(response)
        $(".popup-overlay, .popup-content").addClass("active");
    })
})

$( ".Room" ).hover(
    function() {
    $( this ).append( $( "<span> ***</span>" ) );
    }, function() {
    $( this ).find( "span:last" ).remove();
    }
);