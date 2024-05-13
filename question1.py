import math


def num_len(num: int) -> int:
    """
    :param num: some integer
    :return: integer representing the number of digits in num
    """

    # the minor addition to num to the log10 parameter function is to ensure that powers of ten will also be answered
    # result in mathematically accurate for any n >= 0
    # due to numerical error in the log10 function in practice works for 0 <= num < 10^15
    # the abs function is to handle the n = 0 edge case
    return abs(math.ceil(math.log10(num+0.5)))



