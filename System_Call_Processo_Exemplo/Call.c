#include <unistd.h>
#include <sys/types.h>
#include <stdio.h>
#include <stdlib.h>

int main (int argc, char *argv[], char *envp[])
{
    // identificação do processo
    int pid;
    // criação de um processo filho
    pid = fork();
    // erro de criação
    if (pid < 0)
    {
        perror ("Error: ");
        exit(-1);
    }
    // ainda é o processo pai
     else if (pid > 0)
    {
        // bloqueia o pai e executa o filho
        wait(0);
    }
    // execução pelo processo filho (= 0)
    else
    {
        getchar();
        // troca de programa do processo filho
        execve("/bin/date", argv, envp);
        perror("Error: ");
    }
    printf("Tchau!\n");
    exit(0);
}