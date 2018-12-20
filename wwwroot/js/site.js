$(document).ready(function () { 

    //when room is clicked, take the room name attribute and request for partial view from the server
    $(".Room").on("click", function(){
        var roomName = $(this).attr("data-room")
        $.ajax({
            url : `/${roomName}`,
            method: "get",
        }).done(function (response){
            //take the html response and add onto popup-content. 
            $(".popup-content").html(response)
            //append an "active" class to .popup and .popup-content 
            $(".popup-overlay, .popup-content").addClass("active");
        })
    })

    //removes the "active" class to .popup and .popup-content when the "Close" button is clicked, even on dynamically rendered content
    $(document).on("click", ".close", function(){
        $(".popup-overlay, .popup-content").removeClass("active");
    })
})


