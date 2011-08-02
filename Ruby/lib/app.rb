class Carta
  attr_accessor :valor, :naipe

  def initialize(valor, naipe) 
    @valor = valor
    @naipe = naipe
  end

  def igualValor?(c)
    @valor == c.valor
  end

  def igualNaipe?(c)
    @naipe == c.naipe
  end

  def ehMaiorQue?(c)
    @valor > c.valor
  end

  def ehMenorQue?(c)
    @valor < c.valor
  end
end

class Mao
  def semelhantes (c1, c2, c3, c4, c5)
    
    @a = Hash.new
    
    add c1
    add c2
    add c3
    add c4
    add c5

    @a
  end

  def add c1
    if(@a.key? c1.valor) 
      @a[c1.valor] = @a[c1.valor] + 1 
    else
      @a[c1.valor] = 1 
    end  
  end  
end
