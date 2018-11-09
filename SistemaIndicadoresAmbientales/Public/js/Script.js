

var canvas=null, ctx=null,x=50,y=50;

window.requestAnimationFrame=( function () {
    return window.requestAnimationFrame ||
            window.mozrequestAnimationFrame ||
            window.webkitrequestAnimationFrame ||
            function (callback){
                window.setTimeout(callback,17)
    };
}());

function paint(ctx){
    ctx.fillStyle= '#000';
    ctx.fillRect(0,0,canvas.width,canvas.height);
    
    ctx.fillStyle= '#0f0';
    ctx.fillRect(x,y,10,10);
}

function update(){
    x+=2;
    if(x>canvas.width){
        x=0;
    }
}

function run(){
    window.requestAnimationFrame(run);
    update();
    paint(ctx);
}

function init(){
    canvas=document.getElementById('myCanvas');
    ctx=canvas.getContext('2d');
    run();
}

window.addEventListener('load',init,false);