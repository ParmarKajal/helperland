
  window.onscroll = function () { myFunction() };
  var navbar = document.getElementById("navbar");
  var sticky = navbar.offsetTop;
  function myFunction() {
      if (window.pageYOffset >= sticky)
      {
          navbar.classList.add("sticky")
      } 
      else 
      {
          navbar.classList.remove("sticky");
      }
  } 


  document.querySelector("#first-page").style.transform = "rotate(180deg)";
  document.querySelector("#previous-page").style.transform = "rotate(180deg)";

   function openNav() {
   document.getElementById("mySidebar").style.width = "250px";
   document.getElementById("main").style.marginLeft = "250px";
  }

  function closeNav() {
  document.getElementById("mySidebar").style.width = "0";
  document.getElementById("main").style.marginLeft= "0";
  }

  document.querySelector("#next-page").style.transform = "rotate(180deg)";