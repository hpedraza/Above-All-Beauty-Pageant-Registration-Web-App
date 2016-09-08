$(document).ready( function(){
    $('.navbar-collapse > ul > li').on("click" , function(){
         $(".navbar-toggle").trigger("click");
    });
});