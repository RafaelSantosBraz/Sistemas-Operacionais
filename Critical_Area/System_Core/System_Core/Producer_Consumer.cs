using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Core
{
    class Producer_Consumer
    {
        private Producer producer;
        private Consumer consumer;
        // indica qual é o processo ocupando a CPU no momento
        private bool status;
        // é o buffer de escrita/leitura para comunicação entre o produtor e consumidor
        private List<int> buffer;

        public Producer_Consumer(Producer producer, Consumer consumer)
        {
            this.producer = producer;
            this.consumer = consumer;
            status = true;
        }

        // trasfere a mensagem/conteúdo para o produtor ou consumidor ser executado
        public void transfer_control()
        {
            if (status)
            {
                buffer = producer.execute();                
            }
            else
            {
                consumer.execute(buffer);
            }
            status = !status;
        }

        // método GET para o status da produção/consumo
        public bool Status()
        {
            return status;
        }
    }
}
