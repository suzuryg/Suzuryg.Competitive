#!/bin/bash

oj s -l 4010 $(acc task | awk '{print $3}') ./Combined.csx
