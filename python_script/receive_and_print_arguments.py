# Miércoles, 13 de enero del 2021 [12:34 AM - 01:00 AM Aprox]
# * CÓDIGO QUE RECIBIRÁ E IMPRIMIRÁ LOS ARGUMENTOS RECIBIDOS.
# ! Este código correrá desde C#.

import sys # Para poder recibir argumentos de la terminal.

def main():
    print_received_args(sys.argv)
    return 0

# ------- MÉTODO EN DONDE SE IMPRIME LA LISTA DE ARGUMENTOS RECIBIDOS. ------- #
def print_received_args(args_list):
    # El último argumento indicará el número de instancia de Python que corre.
    print("\n - This was Process number: {}".format(args_list[ len(args_list) - 1]))
    print("\n - [{}] The name of the program is: {}. ".format(args_list[ len(args_list) - 1 ], args_list[0]),
          "This will not count as an argument.")
    # El último argumento no cuenta porque es el número de proceso.
    print("\n - [{}] There were sent a total of {}".format(args_list[ len(args_list) - 1 ], len(args_list) - 2),
          "arguments.\n")
    for i in range(1, len(args_list) - 1):
        print("\n - [{}] ELEMENT [{}] = {}".format(args_list[ len(args_list) - 1 ],
                                                   i - 1, args_list[i]), end="\n")
    print("\n")

if __name__ == "__main__":
    main()
