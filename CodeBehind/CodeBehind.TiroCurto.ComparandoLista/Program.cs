using CodeBehind.TiroCurto.ComparandoLista;
using Newtonsoft.Json;

//comparação tipos primitivos manual
List<int> listaAM = ListaHelper.PreencherLista().Order().ToList();
List<int> listaBM = ListaHelper.PreencherLista().Order().ToList();
listaBM.RemoveAt(0);

Console.WriteLine("-----------------------");
Console.WriteLine("A " + listaAM.Transformar());
Console.WriteLine("B " + listaBM.Transformar());

List<int> diferencaEM = ListaHelper.CompararManualEsquerda(listaAM, listaBM);
List<int> diferencaDM = ListaHelper.CompararManualDireita(listaAM, listaBM);

Console.WriteLine("----------DIFERENÇAS MANUAL-------------");
Console.WriteLine("A " + diferencaEM.Transformar());
Console.WriteLine("B " + diferencaDM.Transformar());


Console.WriteLine("-----------------------");
//comparação tipos primitivos
List<int> listaA = ListaHelper.PreencherLista();
List<int> listaB = ListaHelper.PreencherLista();
listaB.RemoveAt(0);

Console.WriteLine("A " + listaA.Transformar());
Console.WriteLine("B " + listaB.Transformar());

Console.WriteLine("----------DIFERENÇAS EXCEPT-------------");
List<int> diferencaE = ListaHelper.CompararEsquerda(listaA, listaB);
List<int> diferencaD = ListaHelper.CompararDireita(listaA, listaB);

Console.WriteLine("A " + diferencaE.Transformar());
Console.WriteLine("B " + diferencaD.Transformar());


Console.WriteLine("-----------------------");
//comparçao de objetos
var listaAO = ListaHelper.PreencherListaObjeto();
var listaBO = ListaHelper.PreencherListaObjeto();
listaBO.RemoveAt(0);

Console.WriteLine(JsonConvert.SerializeObject(listaAO));
Console.WriteLine(JsonConvert.SerializeObject(listaBO));

Console.WriteLine("----------DIFERENÇAS OBJETO-------------");
var diferencaEO = ListaHelper.ComparaEsquerda<Objeto>(listaAO, listaBO);
var diferencaDO = ListaHelper.ComparaDireita<Objeto>(listaAO, listaBO);

Console.WriteLine(JsonConvert.SerializeObject(diferencaEO));
Console.WriteLine(JsonConvert.SerializeObject(diferencaDO));




Console.WriteLine("-----------------------");
Console.WriteLine(JsonConvert.SerializeObject(listaAO));
Console.WriteLine(JsonConvert.SerializeObject(listaBO));

Console.WriteLine("----------DIFERENÇAS OBJETO LIB-------------");
var ok = ListaHelper.CompararManual(listaAO, listaAO);
var nOK = ListaHelper.CompararManual(listaAO, listaBO);

Console.WriteLine("Lista Igual " + ok);
Console.WriteLine("Lista diferente " + nOK);

Console.ReadKey();

