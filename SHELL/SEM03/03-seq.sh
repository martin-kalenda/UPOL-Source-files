#!/bin/bash

#	- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																										#
# Task:																																																							#
#																																																										#
# Implement a simple version of the seq program: 																																		#
# 	printing of a sequence of whole numbers separated by a space starting from the number given as the 1st argument #
# 	up to the number given as the 3rd argument, the 2nd argument specifies the step between numbers. 								#
#		The step is positive if start <= end and negative otherwise.																										#
#																																																										#
#		If only 2 arguments are given, treat them as start and end and step by 1.																				#
# 	If only 1 argument is given, step by 1 and start from 1.																												#
#																																																										#
#	- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

begin=1
step=1

case $# in
  1)
    end=$1
    ;;

  2)
    begin=$1
    end=$2
    ;;

  3)
    begin=$1
    step=$2
    end=$3
    ;;

  *)
    echo "wrong number of arguments"
    exit -1
    ;;
esac

if [ $begin -le $end ]; then
  while [ $begin -le $end ]; do
    echo -n "$begin "
    let begin=$begin+$step
  done
else
  while [ $begin -ge $end ]; do
    echo -n "$begin "
    let begin=$begin-$step
  done
fi

echo ""
