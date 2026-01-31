using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Infrastructure.Data.Seeds;

public static class ReceitaSeed
{
    public static List<Receita> Criar(List<Ingrediente> ingredientes)
    {
        Ingrediente I(string nome) => ingredientes.First(i => i.Nome == nome);

        List<Receita> receitas = [];

        // LASANHA À BOLONHESA
        Receita lasanha = new("Lasanha à Bolonhesa", "Lasanha clássica com molho de carne", 90, 6, "/fotos-receitas/lasanha-bolonhesa.png");
        lasanha.Ingredientes.Add(new(I("Massa de Lasanha"), 500, "g"));
        lasanha.Ingredientes.Add(new(I("Carne Moída"), 500, "g"));
        lasanha.Ingredientes.Add(new(I("Tomate"), 4, "unidades"));
        lasanha.Ingredientes.Add(new(I("Queijo Mussarela"), 300, "g"));
        lasanha.Ingredientes.Add(new(I("Cebola"), 1, "unidade"));
        lasanha.PassosPreparo.Add(new(1, "Preparar o molho de carne."));
        lasanha.PassosPreparo.Add(new(2, "Montar camadas da lasanha."));
        lasanha.PassosPreparo.Add(new(3, "Assar até gratinar."));
        receitas.Add(lasanha);

        // MACARRÃO COM MOLHO BRANCO E BACON
        Receita penneBacon = new("Penne ao Molho Branco com Bacon", "Massa cremosa com bacon crocante", 40, 4, "/fotos-receitas/penne-molho-branco-bacon.png");
        penneBacon.Ingredientes.Add(new(I("Macarrão Penne"), 400, "g"));
        penneBacon.Ingredientes.Add(new(I("Bacon"), 200, "g"));
        penneBacon.Ingredientes.Add(new(I("Creme de Leite"), 200, "ml"));
        penneBacon.Ingredientes.Add(new(I("Queijo Parmesão"), 50, "g"));
        penneBacon.PassosPreparo.Add(new(1, "Cozinhar o macarrão."));
        penneBacon.PassosPreparo.Add(new(2, "Fritar o bacon."));
        penneBacon.PassosPreparo.Add(new(3, "Preparar o molho branco."));
        receitas.Add(penneBacon);

        // RISOTO DE FRANGO
        Receita risotoFrango = new("Risoto de Frango", "Risoto cremoso com frango", 50, 4, "/fotos-receitas/risoto-frango.png");
        risotoFrango.Ingredientes.Add(new(I("Arroz"), 2, "xícaras"));
        risotoFrango.Ingredientes.Add(new(I("Peito de Frango"), 300, "g"));
        risotoFrango.Ingredientes.Add(new(I("Cebola"), 1, "unidade"));
        risotoFrango.Ingredientes.Add(new(I("Queijo Parmesão"), 50, "g"));
        risotoFrango.PassosPreparo.Add(new(1, "Refogar o frango."));
        risotoFrango.PassosPreparo.Add(new(2, "Adicionar arroz e caldo."));
        risotoFrango.PassosPreparo.Add(new(3, "Finalizar com queijo."));
        receitas.Add(risotoFrango);

        // BOLO VEGANO DE CHOCOLATE
        Receita boloVegano = new("Bolo Vegano de Chocolate", "Bolo macio sem ingredientes de origem animal", 60, 8, "/fotos-receitas/bolo-vegano-chocolate.png");
        boloVegano.Ingredientes.Add(new(I("Farinha de Trigo"), 2, "xícaras"));
        boloVegano.Ingredientes.Add(new(I("Açúcar"), 1, "xícara"));
        boloVegano.Ingredientes.Add(new(I("Chocolate 70%"), 200, "g"));
        boloVegano.Ingredientes.Add(new(I("Leite Vegetal"), 1, "xícara"));
        boloVegano.Ingredientes.Add(new(I("Fermento Químico"), 1, "colher"));
        boloVegano.PassosPreparo.Add(new(1, "Misturar ingredientes secos."));
        boloVegano.PassosPreparo.Add(new(2, "Adicionar líquidos."));
        boloVegano.PassosPreparo.Add(new(3, "Assar até firmar."));
        receitas.Add(boloVegano);

        // BOWL VEGANO DE QUINOA
        Receita bowlQuinoa = new("Bowl Vegano de Quinoa", "Quinoa com legumes assados e grão-de-bico", 45, 2, "/fotos-receitas/bowl-vegano-quinoa.png");
        bowlQuinoa.Ingredientes.Add(new(I("Quinoa"), 1, "xícara"));
        bowlQuinoa.Ingredientes.Add(new(I("Grão-de-bico"), 1, "xícara"));
        bowlQuinoa.Ingredientes.Add(new(I("Abobrinha"), 1, "unidade"));
        bowlQuinoa.Ingredientes.Add(new(I("Cenoura"), 1, "unidade"));
        bowlQuinoa.PassosPreparo.Add(new(1, "Cozinhar a quinoa."));
        bowlQuinoa.PassosPreparo.Add(new(2, "Assar os legumes."));
        bowlQuinoa.PassosPreparo.Add(new(3, "Montar o bowl."));
        receitas.Add(bowlQuinoa);

        // LASANHA DE LEGUMES COM MOLHO BRANCO
        Receita lasanhaLegumes = new("Lasanha de Legumes ao Molho Branco", "Lasanha vegetariana cremosa", 80, 6, "/fotos-receitas/lasanha-legumes-molho-branco.png");
        lasanhaLegumes.Ingredientes.Add(new(I("Massa de Lasanha"), 500, "g"));
        lasanhaLegumes.Ingredientes.Add(new(I("Abobrinha"), 2, "unidades"));
        lasanhaLegumes.Ingredientes.Add(new(I("Cenoura"), 2, "unidades"));
        lasanhaLegumes.Ingredientes.Add(new(I("Creme de Leite"), 200, "ml"));
        lasanhaLegumes.Ingredientes.Add(new(I("Queijo Mussarela"), 300, "g"));
        lasanhaLegumes.PassosPreparo.Add(new(1, "Preparar os legumes."));
        lasanhaLegumes.PassosPreparo.Add(new(2, "Montar camadas da lasanha."));
        lasanhaLegumes.PassosPreparo.Add(new(3, "Assar até gratinar."));
        receitas.Add(lasanhaLegumes);

        // RISOTO DE COGUMELOS
        Receita risotoCogumelos = new("Risoto de Cogumelos", "Risoto cremoso e aromático", 45, 4, "/fotos-receitas/risoto-cogumelos.png");
        risotoCogumelos.Ingredientes.Add(new(I("Arroz"), 2, "xícaras"));
        risotoCogumelos.Ingredientes.Add(new(I("Cogumelo"), 200, "g")); // 👈 FALTAVA
        risotoCogumelos.Ingredientes.Add(new(I("Cebola"), 1, "unidade"));
        risotoCogumelos.Ingredientes.Add(new(I("Queijo Parmesão"), 50, "g"));
        risotoCogumelos.Ingredientes.Add(new(I("Manteiga"), 1, "colher"));
        risotoCogumelos.PassosPreparo.Add(new(1, "Refogar cebola e cogumelos."));
        risotoCogumelos.PassosPreparo.Add(new(2, "Adicionar arroz e caldo."));
        risotoCogumelos.PassosPreparo.Add(new(3, "Finalizar com manteiga e queijo."));
        receitas.Add(risotoCogumelos);

        // ESCONDIDINHO DE CARNE MOÍDA
        Receita escondidinho = new("Escondidinho de Carne Moída", "Carne moída com purê de batata", 70, 6, "/fotos-receitas/escondidinho-carne-moida.png");
        escondidinho.Ingredientes.Add(new(I("Carne Moída"), 500, "g"));
        escondidinho.Ingredientes.Add(new(I("Batata"), 6, "unidades"));
        escondidinho.Ingredientes.Add(new(I("Leite Integral"), 200, "ml"));
        escondidinho.Ingredientes.Add(new(I("Queijo Mussarela"), 200, "g"));
        escondidinho.PassosPreparo.Add(new(1, "Preparar o purê."));
        escondidinho.PassosPreparo.Add(new(2, "Refogar a carne."));
        escondidinho.PassosPreparo.Add(new(3, "Montar e assar."));
        receitas.Add(escondidinho);

        // FRANGO AO MOLHO CREMOSO
        Receita frangoCremoso = new("Frango ao Molho Cremoso", "Frango suculento com molho branco", 50, 4, "/fotos-receitas/frango-molho-cremoso.png");
        frangoCremoso.Ingredientes.Add(new(I("Peito de Frango"), 400, "g"));
        frangoCremoso.Ingredientes.Add(new(I("Creme de Leite"), 200, "ml"));
        frangoCremoso.Ingredientes.Add(new(I("Alho"), 2, "dentes"));
        frangoCremoso.PassosPreparo.Add(new(1, "Dourar o frango."));
        frangoCremoso.PassosPreparo.Add(new(2, "Adicionar molho."));
        frangoCremoso.PassosPreparo.Add(new(3, "Cozinhar até encorpar."));
        receitas.Add(frangoCremoso);

        // SALMÃO AO FORNO COM LEGUMES
        Receita salmaoForno = new("Salmão Assado com Legumes", "Salmão suculento com legumes", 45, 4, "/fotos-receitas/salmao-assado-legumes.png");
        salmaoForno.Ingredientes.Add(new(I("Filé de Salmão"), 500, "g"));
        salmaoForno.Ingredientes.Add(new(I("Batata"), 3, "unidades"));
        salmaoForno.Ingredientes.Add(new(I("Cenoura"), 2, "unidades"));
        salmaoForno.PassosPreparo.Add(new(1, "Temperar o salmão."));
        salmaoForno.PassosPreparo.Add(new(2, "Dispor legumes."));
        salmaoForno.PassosPreparo.Add(new(3, "Assar até dourar."));
        receitas.Add(salmaoForno);

        // BOLO VEGANO DE CENOURA
        Receita boloCenouraVegano = new("Bolo Vegano de Cenoura", "Bolo fofinho sem ingredientes animais", 60, 8, "/fotos-receitas/bolo-vegano-cenoura.png");
        boloCenouraVegano.Ingredientes.Add(new(I("Cenoura"), 3, "unidades"));
        boloCenouraVegano.Ingredientes.Add(new(I("Farinha de Trigo"), 2, "xícaras"));
        boloCenouraVegano.Ingredientes.Add(new(I("Açúcar"), 1, "xícara"));
        boloCenouraVegano.Ingredientes.Add(new(I("Leite Vegetal"), 1, "xícara"));
        boloCenouraVegano.Ingredientes.Add(new(I("Fermento Químico"), 1, "colher"));
        boloCenouraVegano.PassosPreparo.Add(new(1, "Bater a cenoura."));
        boloCenouraVegano.PassosPreparo.Add(new(2, "Misturar os ingredientes."));
        boloCenouraVegano.PassosPreparo.Add(new(3, "Assar até dourar."));
        receitas.Add(boloCenouraVegano);

        // ARROZ DE FORNO COM QUEIJO
        Receita arrozForno = new("Arroz de Forno Cremoso", "Arroz gratinado com queijo", 50, 6, "/fotos-receitas/arroz-forno-cremoso.png");
        arrozForno.Ingredientes.Add(new(I("Arroz"), 3, "xícaras"));
        arrozForno.Ingredientes.Add(new(I("Creme de Leite"), 200, "ml"));
        arrozForno.Ingredientes.Add(new(I("Queijo Mussarela"), 300, "g"));
        arrozForno.PassosPreparo.Add(new(1, "Misturar os ingredientes."));
        arrozForno.PassosPreparo.Add(new(2, "Levar ao forno."));
        arrozForno.PassosPreparo.Add(new(3, "Gratinar."));
        receitas.Add(arrozForno);

        // MACARRÃO À CARBONARA
        Receita carbonara = new("Macarrão à Carbonara", "Clássico italiano com bacon", 35, 4, "/fotos-receitas/macarrao-carbonara.png");
        carbonara.Ingredientes.Add(new(I("Macarrão Penne"), 400, "g"));
        carbonara.Ingredientes.Add(new(I("Bacon"), 200, "g"));
        carbonara.Ingredientes.Add(new(I("Ovos"), 3, "unidades"));
        carbonara.Ingredientes.Add(new(I("Queijo Parmesão"), 50, "g"));
        carbonara.PassosPreparo.Add(new(1, "Cozinhar a massa."));
        carbonara.PassosPreparo.Add(new(2, "Fritar o bacon."));
        carbonara.PassosPreparo.Add(new(3, "Misturar tudo fora do fogo."));
        receitas.Add(carbonara);

        // GRATINADO DE BATATA COM QUEIJO
        Receita batataGratinada = new("Batata Gratinada", "Batata cremosa com queijo", 60, 6, "/fotos-receitas/batata-gratinada.png");
        batataGratinada.Ingredientes.Add(new(I("Batata"), 6, "unidades"));
        batataGratinada.Ingredientes.Add(new(I("Creme de Leite"), 200, "ml"));
        batataGratinada.Ingredientes.Add(new(I("Queijo Parmesão"), 100, "g"));
        batataGratinada.PassosPreparo.Add(new(1, "Cortar as batatas."));
        batataGratinada.PassosPreparo.Add(new(2, "Montar camadas."));
        batataGratinada.PassosPreparo.Add(new(3, "Assar até gratinar."));
        receitas.Add(batataGratinada);

        // ENSOPADO DE LENTILHA VEGANO
        Receita ensopadoLentilha = new("Ensopado Vegano de Lentilha", "Prato vegano rico em proteínas", 55, 4, "/fotos-receitas/ensopado-vegano-lentilha.png");
        ensopadoLentilha.Ingredientes.Add(new(I("Lentilha"), 2, "xícaras"));
        ensopadoLentilha.Ingredientes.Add(new(I("Cenoura"), 2, "unidades"));
        ensopadoLentilha.Ingredientes.Add(new(I("Cebola"), 1, "unidade"));
        ensopadoLentilha.PassosPreparo.Add(new(1, "Refogar os legumes."));
        ensopadoLentilha.PassosPreparo.Add(new(2, "Adicionar lentilha e água."));
        ensopadoLentilha.PassosPreparo.Add(new(3, "Cozinhar até encorpar."));
        receitas.Add(ensopadoLentilha);

        return receitas;
    }
}
