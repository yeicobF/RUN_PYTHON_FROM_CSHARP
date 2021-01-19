# Miércoles, 13 de enero del 2021 [12:34 AM - 01:00 AM Aprox]
# * CÓDIGO QUE RECIBIRÁ E IMPRIMIRÁ LOS ARGUMENTOS RECIBIDOS.
# ! Este código correrá desde C#.
# 
# 1.- RECIBE EL NOMBRE DEL PROGRAMA EN C# COMO PRIMER ARGUMENTO.
# 2.- RECIBE LOS ARGUMENTOS A MOSTRAR.
# 3.- RECIBE EL NÚMERO DE INSTANCIA/PROCESO QUE CORRE ESTE PROGRAMA.
# 
# SOLO SE IMRPIMEN LOS ARGUMENTOS DE LA PRIMERA Y SEGUNDA SECCIÓN.

import sys # Para poder recibir argumentos de la terminal.
from random import randint # Números random.
from time import sleep # Para dormir el programa n segundos.

def main():
    time_to_sleep = get_time_to_run_program()
    print("\n\n - AFTER THE PRINT IS DONE, THE PROGRAM WILL",
          "SLEEP {} SECONDS\n\n".format(time_to_sleep), sep=" ")
    print_received_args(sys.argv)
    print("\n\n - SLEEPING {} SECONDS...\n\n".format(time_to_sleep))
    sleep(time_to_sleep) # Dormir el programa este tiempo.
    print("\n\n - SLEPT FOR {} SECONDS...\n\n".format(time_to_sleep))
    return 0

# ------- MÉTODO EN DONDE SE IMPRIME LA LISTA DE ARGUMENTOS RECIBIDOS. ------- #
def print_received_args(args_list):
    # El último argumento indicará el número de instancia de Python que corre.
    print("\n - [This was Process number: {}]".format(args_list[ len(args_list) - 1]))
    print("\n - [{}] The name of the program is: {}. ".format(args_list[ len(args_list) - 1 ], args_list[0]),
          "This will not count as an argument.")
    # El último argumento no cuenta porque es el número de proceso.
    print("\n - [{}] There were sent a total of {}".format(args_list[ len(args_list) - 1 ], len(args_list) - 2),
          "arguments.\n")
    for i in range(1, len(args_list) - 1):
        print("\n - [{}] ELEMENT [{}] = {}".format(args_list[ len(args_list) - 1 ],
                                                   i - 1, args_list[i]), end="\n")
    print("\n")

# Método para obtener un tiempo aleatorio que durará el programa.
#    time.sleep(segundos)
#    FUENTE: https://www.programiz.com/python-programming/time/sleep
# 
# - NÚMEROS RANDOM: randint(min, max) para enteros. Inlcuye mínimo y máximo.
#   FUENTE: https://machinelearningmastery.com/how-to-generate-random-numbers-in-python/

def get_time_to_run_program():
    # Durará entre 5 y 15 segundos el programa.
    return randint(5, 15)


if __name__ == "__main__":
    main()
