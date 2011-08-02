require 'app'

describe Carta do
  it "dado 2 cartas, ver a maior carta" do
    carta1 = Carta.new(2, 'D')
    carta2 = Carta.new(10, 'S')

    carta1.valor.should < carta2.valor
  end

  it "dado 2 cartas iguais, ver que sao iguais" do
    carta1 = Carta.new(2, 'D')
    carta2 = Carta.new(2, 'D')

    carta1.igualValor?(carta2).should == true
  end

  it "dado 2 cartas, ver se os naipes sao iguais" do
    carta1 = Carta.new(2, 'D')
    carta2 = Carta.new(3, 'D')

    carta1.igualNaipe?(carta2).should == true
  end

  it "dado 2 cartas, ver se os naipes sao diferentes" do
    carta1 = Carta.new(2, 'D')
    carta2 = Carta.new(3, 'H')

    carta1.igualNaipe?(carta2).should == false
  end

  it "dado 2 cartas, ver se uma eh maior que a outra" do
    carta1 = Carta.new(2, 'D')
    carta2 = Carta.new(3, 'H')

    carta1.ehMaiorQue?(carta2).should == false
  end

  it "dado 2 cartas, ver se uma eh menor que a outra" do
    carta1 = Carta.new(4, 'D')
    carta2 = Carta.new(3, 'H')

    carta1.ehMenorQue?(carta2).should == false
  end

  it "dado 6 cartas, ver semelhantes" do
    carta1 = Carta.new(4, 'D')
    carta2 = Carta.new(3, 'H')
    carta3 = Carta.new(6, 'H')
    carta4 = Carta.new(6, 'H')
    carta5 = Carta.new(6, 'H')

    mao = Mao.new
    mao.semelhantes(carta1, carta2, carta3, carta4, carta5).should ==
      {4 => 1, 3 => 1, 6 => 3}
  end



end
