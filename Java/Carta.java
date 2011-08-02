package dojo;

public class Carta {
	private Integer numero;
	private String nipe;
	
	public Carta(String valor) {
		valor = "0" + valor;
		
		if(valor.charAt(1) == 'J') {
			this.numero = 11;
		} else if(valor.charAt(1) == 'Q') {
			this.numero = 12;
		}else if(valor.charAt(1) == 'K') {
			this.numero = 13;
		}else if(valor.charAt(1) == 'A') {
			this.numero = 14;
		}		
		else {			
			this.numero = Integer.parseInt((String) valor.subSequence(0, 2));
		}
				
		this.nipe = (String) valor.subSequence(2, 3);
	}	
	
	public String get(){
		return numero.toString() + nipe;
	}

	public int getNumero() {
		return this.numero;
	}

	public String getNipe() {		
		return nipe;
	}

	public boolean maiorQue(Carta carta) {
		return this.numero > carta.getNumero();
	}
}
