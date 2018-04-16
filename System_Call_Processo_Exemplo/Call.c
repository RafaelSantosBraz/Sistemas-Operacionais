#include <unistd.h>
#include <sys/types.h>
#include <stdio.h>
#include <stdlib.h>

int main (int argc, char *argv[], char *envp[])
{
    int pid;
    pid = fork();
    if (pid < 0)
    {
        perror ("Error: ");
        exit(-1);
    }
    else if (pid > 0)
    {
        wait(0);
    }
    else
    {
        execve("/bin/date", argv, envp);
        perror("Error: ");
    }
    printf("Tchau!\n");
    exit(0);
}