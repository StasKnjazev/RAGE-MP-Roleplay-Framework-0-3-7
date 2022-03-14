console.clear();

var speed = null;
var indexPB = null;
var initialDash = null;
var currentDash = null;

var can = null;
var c = null;

var posX = null;
var posY = null;
var fps = null;
var procent = null;
var oneProcent = null;
var result = null;
var radius = null;

function init(egal, time) {
    egal = egal;
    speed = time / 1000;
    indexPB = speed * 60; // 60 FPS
    initialDash = 440;
    currentDash = 600;
    
    can = document.getElementById('canvas');
    c = can.getContext('2d');
    
    posX = can.width / 2;
    posY = can.height / 2;
    fps = 60;
    procent = 0;
    oneProcent = 360 / 100;
    result = oneProcent * 64;
    radius = 70;

    function myFunction () {
        indexPB--;
        var percentage = getPercentage(indexPB, speed);
      
        timer();
        svg();
        progressBar(percentage);
        canvas(percentage);
      
      
        if (indexPB !== 0) {
          requestAnimationFrame(myFunction);
        }
      }
      requestAnimationFrame(myFunction);
      
      
      
      function progressBar(percentage) {
        var progress = $('.progressbarfill');
        
        progress.width(percentage + '%');
      }
      
      function timer() {
        $('.timer').html((Math.round((indexPB * 1000 / (600) / 100) * 10 ) / 10).toFixed(1));
      }
      
      function svg() {
        var dash = indexPB * initialDash / (speed * 60);
        $('.circle-animation').css('stroke-dashoffset', dash);
      }
      
      function canvas(percentage) {
        var color = '';
        if(percentage >= 66) {
          color = '#00ec90';
        } else if(percentage < 66 && percentage > 20) {
          color = 'orange';
        } else if(percentage <= 20) {
          color = 'red';
        }
        c.clearRect(0, 0, can.width, can.height);
       
        c.beginPath();
        c.arc(posX, posY, radius, (Math.PI/180) * 270,  (Math.PI/180) * (270 + 360));
        c.lineWidth = 16;
        c.strokeStyle = 'lightgrey';
        c.stroke();
        
        c.beginPath();
        c.arc(posX, posY, radius, (Math.PI/180) * 270, (Math.PI/180) * (270 + (360 - (percentage * 360 / 100))), false);
        c.lineWidth = 16;
        c.strokeStyle = color;
        c.stroke();
      }
      
      
      function getPercentage(current, max) {
        return current * 100 / (max * 60);
      }
}

