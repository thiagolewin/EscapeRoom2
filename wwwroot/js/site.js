const button = document.querySelector(".botonPista")
const pista = document.querySelector(".pista")
const main = document.querySelector("#mainGanador")
const nav = document.querySelector("nav")
let pistasUsadas = document.querySelector(".pistas")
let pistasUsadasPagina = 0
let horas = 0
let minutos = 0
let segundos = 0;
let fechaDeReferencia = new Date()
if (main) {
    main.style.height = window.innerHeight - nav.clientHeight -1 + "px";
}
console.log("a")
const separador = document.querySelector(".separador")
let n = 0;
function ShowPista() {
    pistasUsadasPagina++
    console.log(pistasUsadas.value)
    if(pistasUsadasPagina <3) {
        pistasUsadas.value = parseInt(pistasUsadas.value) +1
    }
    pista.style.display = "flex"
    pista.style.left = 200
    pista.style.left = "0px"
    pista.children[1].style.transform =  "rotate(0)"
    if (n<pista.children[0].childElementCount) {
        pista.children[0].children[n].style.display = "block"
        if(n > 0) {
            pista.children[0].children[n-1].style.marginBottom = "15px"
        }
    }
    n++;
    separador.style.height = pista.clientHeight + "px" 
}

function CerrarPista(){
    if(pista.style.left== "0px") {
        pista.style.left = -pista.clientWidth + separador.clientWidth + "px"
        pista.children[1].style.transform =  "rotate(180deg)"
    } else {
        pista.style.left = "0px"
        pista.children[1].style.transform =  "rotate(0)"
    }
}
function actualizarTimer() {
    let timer = document.querySelector(".contador").children[0]
    let tiempo = timer.textContent
    let inputTimer = document.querySelector(".inputTimer")
    horas = parseInt((tiempo[0] + tiempo[1]))
    minutos = parseInt((tiempo[3] + tiempo[4]))
    segundos = parseInt((tiempo[6] + tiempo[7]))
    if (timer) {
        segundos++;
        if (segundos == 60) {
            segundos = 0
            minutos ++
        }
        if (minutos == 60) {
            minutos = 0
            horas++
        }
        if (horas == 24) {
            horas = 0
        }
        segundos = segundos.toString().padStart(2,"0")
        minutos = minutos.toString().padStart(2,"0")
        horas = horas.toString().padStart(2,"0")
        timer.textContent = horas + ":" + minutos + ":" + segundos;
        inputTimer.value = timer.textContent
    }
}
actualizarTimer()
setInterval(actualizarTimer, 1000);