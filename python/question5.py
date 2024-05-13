import math


def reverse_n_pi_digits(n: int) -> str:
    """

    :param n:
    :return: first n digits of pi reversed.
    """
    with open("pi.txt", 'r') as file:
        # This will achieve far more digits of pi then is possible with math.pi or any one line function.
        # file is included.
        if n == 1:
            return "3"
        # to solve with math replace with math.pi[n::-1] however will only work for small n
        return file.read()[n::-1]

