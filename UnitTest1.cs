using System.Numerics;
using System.Xml.Linq;
using System;

namespace CS.TP1.Aula7.Test
{
    public class UnitTest1
    {
        // Adicionar contato
        [Fact]
        public void TestAddValidContact()
        {
            // Arrange - prepara o ambiente de teste
            var expected = true;

            var contactService = new ContactService();

            // Act - Executa os testes
            var result = contactService.AddContact("Teste", "123456789", "teste@exemplo.com");

            // Assert - Verifica os resultados
            Assert.Equal(expected, result);  
        }

        [Fact]
        public void TestAddInvalidContact()
        {
            var expected = false;
            var contactService = new ContactService();
            var result = contactService.AddContact(null, " ", " ");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestAddDuplicateContact()
        {
            var expected = false;
            var contactService = new ContactService();
            contactService.AddContact("Teste", "123456789", "teste@exemplo.com");
            var result = contactService.AddContact("Teste", "123456789", "teste@exemplo.com");

            Assert.Equal(expected, result);
        }

        // Listar contatos
        
        [Fact]
        public void TestListContacts()
        {
            var expected = "Lista de contatos:\n" +
                           "1. Maria - 1234 - teste1@example.com\n" +
                           "2. Jo�o - 5678 - teste2@example.com\n" +
                           "3. Fulano - 9876 - teste3@example.com\n";

            var contactService = new ContactService();
            contactService.contacts.Add(new Contact("Maria", "1234", "teste1@example.com"));
            contactService.contacts.Add(new Contact("Jo�o", "5678", "teste2@example.com"));
            contactService.contacts.Add(new Contact("Fulano", "9876", "teste3@example.com"));

            var result = contactService.ListContacts();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestEmptyListContacts()
        {
            var expected = "N�o h� contatos cadastrados.";

            var contactService = new ContactService();
            var result = contactService.ListContacts();

            Assert.Equal(expected, result);
        }

        // Atualizar contato
        
        [Fact]
        public void TestUpdateValidContact()
        {
            var expected = "Contato 'Joana' atualizado com sucesso.";

            var contactService = new ContactService();
            contactService.contacts.Add(new Contact("Maria", "1234", "teste1@example.com"));

            var result = contactService.UpdateContact(0, "Joana", "1234", "teste1@example.com");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestUpdateInvalidContactTop()
        {
            var expected = "�ndice inv�lido. Tente novamente.";

            var contactService = new ContactService();
            contactService.contacts.Add(new Contact("Maria", "1234", "teste1@example.com"));

            var result = contactService.UpdateContact(5, "Joana", "1234", "teste1@example.com");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestUpdateValidContactBottom()
        {
            var expected = "�ndice inv�lido. Tente novamente.";

            var contactService = new ContactService();
            contactService.contacts.Add(new Contact("Maria", "1234", "teste1@example.com"));

            var result = contactService.UpdateContact(-5, "Joana", "1234", "teste1@example.com");

            Assert.Equal(expected, result);
        }

        // Remover contato

        [Fact]
        public void TestRemoveValidContact()
        {
            var expected = "Contato 'Maria' removido com sucesso.";

            var contactService = new ContactService();
            contactService.contacts.Add(new Contact("Maria", "1234", "teste1@example.com"));

            var result = contactService.RemoveContact(0);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestRemoveInvalidContactTop()
        {
            var expected = "�ndice inv�lido. Tente novamente.";

            var contactService = new ContactService();
            contactService.contacts.Add(new Contact("Maria", "1234", "teste1@example.com"));

            var result = contactService.RemoveContact(5);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestRemoveInvalidContactBottom()
        {
            var expected = "�ndice inv�lido. Tente novamente.";

            var contactService = new ContactService();
            contactService.contacts.Add(new Contact("Maria", "1234", "teste1@example.com"));

            var result = contactService.RemoveContact(-5);

            Assert.Equal(expected, result);
        }
    }
}