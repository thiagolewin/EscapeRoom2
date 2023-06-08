const button = document.querySelector(".botonPista")
const pista = document.querySelector(".pista")
const main = document.querySelector("main")
const separador = document.querySelector(".separador")
let n = 0;
function ShowPista() {
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