$(document).ready(function () {
var header = document.getElementById("navbarNav");
var head = document.getElementById("head");
var current = document.getElementsByClassName("active");
var btns = header.getElementsByClassName("nav-item");

head.addEventListener("click", function () {
  if (current && current.length > 0)
    current[0].className = current[0].className.replace(" active", "");
})
for (var i = 0; i < btns.length; i++) {
  btns[i].addEventListener("click", function () {
    if (current && current.length > 0)
      current[0].className = current[0].className.replace(" active", "");
    this.className += " active";
  });
}

  // Add scrollspy to <body>
  $('body').scrollspy({
    target: ".navbar",
    offset: 80
  });

  // Add smooth scrolling on all links inside the navbar
  $("#navbarNav a").on('click', function (event) {
    // Make sure this.hash has a value before overriding default behavior
    if (this.hash !== "") {
      // Prevent default anchor click behavior
      event.preventDefault();

      // Store hash
      var hash = this.hash;

      // Using jQuery's animate() method to add smooth page scroll
      // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
      $('html, body').animate({
        scrollTop: $(hash).offset().top
      }, 800, function () {

        // Add hash (#) to URL when done scrolling (default click behavior)
        window.location.hash = hash;
      });
    }
  });

  $('#mymodal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('number') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    var name = "";
    var imageurl = "";
    switch (recipient) {
      case 1:
        name = "O casa frumoasa";
        imageurl = "img/cabin.png";
        break;
      case 2:
        name = "O cabina frumoasa";
        imageurl = "img/cake.png";
        break;
      case 3:
        name = "Circ minunat";
        imageurl = "img/circus.png";
        break;
      case 4:
        name = "Hai la joaca";
        imageurl = "img/game.png";
        break;
      case 5:
        name = "ieei";
        imageurl = "img/safe.png";
        break;
      case 6:
        name = "Un subamarin frumos";
        imageurl = "img/submarine.png";
        break;

    }
    modal.find('.portfolio-modal-title').text(name)
    var image = modal.find('.modal-body img')
    image[0].src = imageurl


  })



});