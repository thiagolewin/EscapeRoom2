const button = document.querySelector(".botonPista")
const pista = document.querySelector(".pista")
const main = document.querySelector("main")
const separador = document.querySelector(".separador")
button.addEventListener("click",()=>{
    pista.style.display = "flex"
    pista.style.left = 200
    console.log("a")
    console.log(pista.children[0].children[1])
    pista.children[0].children[1].style.display = "block"
})
pista.children[1].addEventListener("click",()=>{
    separador.style.height = pista.clientHeight + "px"
    if(pista.style.left== "0px") {
        pista.style.left = -pista.clientWidth + separador.clientWidth + "px"
        pista.children[1].style.transform =  "rotate(180deg)"
    } else {
        pista.style.left = "0px"
        pista.children[1].style.transform =  "rotate(0)"
    }

})