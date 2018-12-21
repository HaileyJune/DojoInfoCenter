function ShowPerLocation(locationName) {
    console.log("*****ShowPerLocation was called!******")
    $.ajax({
        url : `/${locationName}`,
        method: "get",
    }).done(function (newpage){
        $(".popup-content").html(newpage)
        $(".popup-overlay, .popup-content").addClass("active");
    })
}

function ReloadLatest(){
    console.log("*****ReloadLatest was called!******")
    $.ajax({
        url : `/latest`,
        method: "get",
    }).done(function (newpage){
        $(".Latest_activity").html(newpage);
    })
}

//when room is clicked, take the room name attribute and request for partial view from the server
    $(".Room").on("click", function(){
        var roomName = $(this).attr("data-room")
        ShowPerLocation(roomName) 
    })

    //removes the "active" class to .popup and .popup-content when the "Close" button is clicked, even on dynamically rendered content
    $(document).on("click", ".close", function(){
        $(".popup-overlay, .popup-content").removeClass("active");
    })


    $(document).on("click", ".postNewMessage", function(e){
        e.preventDefault()
        console.log("*******ajax post form is working*******")
        var data = $(".newMessageForm").serialize()
        $.ajax({
            url: '/newMessage',
            method: 'post',
            data: data
        })
        .done(function(res){
            ShowPerLocation(res)
            ReloadLatest() 
        })
    });

$( ".Room" ).hover(
    function() {
    $( this ).addClass("hover");
    }, function() {
    $( this ).removeClass("hover");
    }
);