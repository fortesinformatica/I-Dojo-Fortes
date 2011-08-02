package dojo;

import java.util.ArrayList;

public class Mao {
	private ArrayList<Carta> cartas;
	
	public Mao(ArrayList<Carta> cartas) {
		this.cartas = cartas;
	}

	public ArrayList<Carta> getCartas() {
		return cartas;
	}
	
	public int quantidadeDeCartas() {
		return cartas.size();		
	}

	public Object queJogoTenho() {
		
		return null;
	}
	
	public boolean tenhoUmPar(){
		for(int cartaAtual = 0; cartaAtual < cartas.size(); cartaAtual++ ) {
			for(int j = 1; j < cartas.size(); j++) {
				if(cartas.get(cartaAtual).getNumero() == cartas.get(j).getNumero())
					return true;
			}
		}
		return false;
	}
	
	public boolean tenhoDoisPares(){
		boolean tenhoUmPar = false;		
		
		for(int cartaAtual = 0; cartaAtual < cartas.size(); cartaAtual++ ) {
			for(int j = 1; j < cartas.size(); j++) {
				if(cartas.get(cartaAtual).getNumero() == cartas.get(j).getNumero())
					if( !tenhoUmPar ){
						
					} else {
						
					}
			}
		}
		return false;
	}
}
