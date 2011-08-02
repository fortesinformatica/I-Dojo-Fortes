package dojo;

import java.util.ArrayList;

import org.junit.Test;

import junit.framework.Assert;

public class PokerTest {
	@Test
	public void possoIdentificar5DeCopas(){
		Carta carta = new Carta("5C");
		
		Assert.assertEquals("Número deve ser 5", 5, carta.getNumero());
		Assert.assertEquals("Nipe deve ser C", "C", carta.getNipe());
		Assert.assertEquals("deveria ser 5C", "5C", carta.get());		
	}
	
	@Test
	public void valeteDeveSerMapeadoPara11(){
		Carta carta = new Carta("JC");
		
		Assert.assertEquals("Número deve ser 11", 11, carta.getNumero());		
	}
	@Test
	public void valeteDeveSerMapeadoPara12(){
		Carta carta = new Carta("QC");
		
		Assert.assertEquals("Número deve ser 12", 12, carta.getNumero());		
	}
	@Test
	public void valeteDeveSerMapeadoPara13(){
		Carta carta = new Carta("KC");
		
		Assert.assertEquals("Número deve ser 13", 13, carta.getNumero());		
	}
	@Test
	public void valeteDeveSerMapeadoPara14(){
		Carta carta = new Carta("AC");
		
		Assert.assertEquals("Número deve ser 14", 14, carta.getNumero());		
	}
	
	@Test
	public void possoIndetificarCartaMaisAlta(){
		Carta carta1 = new Carta("9S");
		Carta carta2 = new Carta("5C");
		
		Assert.assertTrue("carta1 deve ser maior que carta2", carta1.maiorQue(carta2));
	}
	
	@Test
	public void umaMaoDeveTer5Cartas() {
		Mao mao;
		ArrayList<Carta> cartas = new ArrayList<Carta>();
		Carta carta1 = new Carta("5H");
		Carta carta2 = new Carta("6S");
		Carta carta3 = new Carta("8S");
		Carta carta4 = new Carta("7H");
		Carta carta5 = new Carta("10C");
		
		cartas.add(carta1);
		cartas.add(carta2);
		cartas.add(carta3);
		cartas.add(carta4);
		cartas.add(carta5);
		
		mao = new Mao(cartas);
		
		Assert.assertEquals("Deve ter 5 cartas", 5, mao.quantidadeDeCartas());
	}
	
	@Test 
	public void umaMaoDeveTerUmPar(){
		Mao mao;
		ArrayList<Carta> cartas = new ArrayList<Carta>();
		Carta carta1 = new Carta("5H");
		Carta carta2 = new Carta("6S");
		Carta carta3 = new Carta("1S");
		Carta carta4 = new Carta("5H");
		Carta carta5 = new Carta("10C");
		
		cartas.add(carta1);
		cartas.add(carta2);
		cartas.add(carta3);
		cartas.add(carta4);
		cartas.add(carta5);
		
		mao = new Mao(cartas);
		
		Assert.assertEquals("Deve ter um par", true, mao.tenhoUmPar());
	}
}
