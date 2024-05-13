def is_sorted_polyndrom(st: str) -> bool:
    """

    :param st:
    :return: True if string is sorted to its half and is a PALINDROME False otherwise
    """
    for i in range(len(st)//2-1):
        # check to make sure that not only are the letters ascending but also equal to its mirror letter
        if st[i] > st[i+1] or st[i] != st[len(st)-i-1]:
            return False
    return True


