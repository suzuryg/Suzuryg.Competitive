#!/bin/bash

oj s -l 4010 $(acc task | awk '{print $NF}') ./Combined.csx
