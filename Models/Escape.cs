using System.Collections.Generic;
static public class Escape {
    public static string[] incognitasSalas {get; private set;} = new string[5];
    public static string[] titulos {get;private set;} = new string[5];
    public static Dictionary<int,string[]> pistaSalas {get; private set;} = new Dictionary<int,string[]>();
    public static string[] acertijo = new string[5];
    public static int estadoJuego {get; private set;} = 1;

    private static void InicializarJuego() {
        if (pistaSalas.Count()==0)
        {

            incognitasSalas[0] = "Celda";
            incognitasSalas[1] = "Puente";
            incognitasSalas[2] = "Cadena";
            incognitasSalas[3] = "Llave";
            incognitasSalas[4] = "Muro";

            string[] pistas1 = new string[2];
            pistas1[0] = "Es un lugar donde los prisioneros pasan su tiempo";
            pistas1[1] = "Es una pequeña habitación con barrotes";
            pistaSalas.Add(0, pistas1);
            
            string[] pistas2 = new string[2];
            pistas2[0] = "Es una estructura que conecta dos puntos";
            pistas2[1] = "Se necesita para cruzar un obstáculo";
            pistaSalas.Add(1, pistas2);

            string[] pistas3 = new string[2];
            pistas3[0] = "Es un objeto que limita la libertad de movimiento";
            pistas3[1] = "Se utiliza para mantener a las personas sujetas";
            pistaSalas.Add(2, pistas3);

            string[] pistas4 = new string[2];
            pistas4[0] = "Es un objeto que se utiliza para abrir cerraduras";
            pistas4[1] = "Se usa para desbloquear puertas y liberar personas";
            pistaSalas.Add(3, pistas4);

            string[] pistas5 = new string[2];
            pistas5[0] = "Es una estructura que rodea un espacio";
            pistas5[1] = "Puede representar un obstáculo para la libertad";
            pistaSalas.Add(4, pistas5);

            titulos[0] = "Fase 1: 'El Inicio de la Condena'";
            titulos[1] = "Fase 2: 'El Camino de la Libertad'";
            titulos[2] = "Fase 3: 'La Búsqueda de la Evasión'";
            titulos[3] = "Fase 4: 'La Clave de la Libertad'";
            titulos[4] = "Fase 5: 'La Última Barrera'";
            acertijo[0]= "Tiene llaves que no abre cerraduras, tiene espacio pero no se puede tocar. ¿Qué es?";
            acertijo[1] = "Lo construyen aquellos que lo necesitan, lo usan aquellos que lo tienen, pero nunca lo ven. ¿Qué es?";
            acertijo[2] = "Es la única cosa que los prisioneros desean romper. Todos la tienen, pero nadie la comparte. ¿Qué es?";
            acertijo[3] = "Tiene dientes pero no puede morder, tiene un cuello pero no puede girar. ¿Qué es?";
            acertijo[4] = "Cuando más grande, más pequeño se vuelve, pero si lo derrumbas, todos se alegrarán. ¿Qué es?";
        }
    }

    public static string[] GetPistas(int sala)
    {
        return pistaSalas[sala];
    }
    public static string GetAcertijos(int sala) {
        return acertijo[sala];
    }
       public static string GetTitulo(int sala) {
        return titulos[sala];
    }
    public static int GetEstadoJuego() {
        if (estadoJuego == 1) {
        InicializarJuego();
        }
        return estadoJuego;
    }
    public static bool ResolverSala(int sala, string incognita) {
        int salaActual = GetEstadoJuego();
        if (sala> salaActual) {
            return false;
        } else {
            if (incognita.ToLower() == incognitasSalas[sala-1].ToLower()) {
                estadoJuego++;
                return true;
            } else {
                return false;
            }
        }
    }
}