using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Fifth
{
    class QuackVm
    {
        private ushort[] _queue;
        private int _head;
        private int _tail;

        private string[] _program;
        private ushort[] registers;//-97

        public QuackVm()
        {
            _queue = new ushort[100000];
            _head = 0;
            _tail = 0;
            registers = new ushort[26];
        }

        private ushort _get()
        {
            ushort val = _queue[_head];
            if (_head != _tail)
            {
                _head = (_head == 99999) ? 0 : _head + 1;
            }
            return val;
        }

        private void _put(ushort val)
        {
            _queue[_tail] = val;
            _tail = (_tail == 99999) ? 0 : _tail + 1;
        }

        public void LoadProgram()
        {
            List<string> temp = new List<string>();
            string inp;
            while ((inp = Console.ReadLine()) != null && inp != "")
            {
                temp.Add(inp);
            }

            _program = temp.ToArray();

        }
        public void Run()
        {
            int i = 0;
            ushort a;
            ushort b;
            int regId;
            int regIdTw;
            string marker;
            while (i < _program.Length)
            {
                string command = _program[i];
                switch (command[0])
                {
                    case '+':
                        a = _get();
                        b = _get();
                        _put((ushort)((a + b) % 65536));
                        break;
                    case '-':
                        a = _get();
                        b = _get();
                        _put((ushort)((a - b) % 65536));
                        break;
                    case '*':
                        a = _get();
                        b = _get();
                        _put((ushort)((a * b) % 65536));
                        break;
                    case '/':
                        a = _get();
                        b = _get();
                        if (b == 0)
                        {
                            _put(0);
                        }
                        else
                        {
                            _put((ushort)(a / b));
                        }
                        break;
                    case '%':
                        a = _get();
                        b = _get();
                        if (b == 0)
                        {
                            _put(0);
                        }
                        else
                        {
                            _put((ushort)(a % b));
                        }
                        break;
                    case '>':
                        a = _get();
                        regId = ((int)command[1]) - 97;
                        registers[regId] = a;
                        break;
                    case '<':
                        regId = ((int)command[1]) - 97;
                        _put(registers[regId]);
                        break;
                    case 'P':
                        if (command.Length == 1)
                        {
                            Console.WriteLine(_get());
                        }
                        else
                        {
                            regId = ((int)command[1]) - 97;
                            Console.WriteLine(registers[regId]);
                        }
                        break;
                    case 'C':
                        if (command.Length == 1)
                        {
                            Console.Write((char)(_get() % 256));
                        }
                        else
                        {
                            regId = ((int)command[1]) - 97;
                            Console.Write((char)(registers[regId] % 256));
                        }
                        break;
                    case ':':
                        break;
                    case 'J':
                        marker = command.Replace('J', ':');
                        i = Array.IndexOf(_program, marker);
                        break;
                    case 'Z':
                        regId = ((int)command[1]) - 97;
                        if (registers[regId] == 0)
                        {
                            marker = command.Remove(1, 1).Replace('Z', ':');
                            i = Array.IndexOf(_program, marker);
                        }
                        break;
                    case 'E':
                        regId = ((int)command[1]) - 97;
                        regIdTw = ((int)command[2]) - 97;
                        if (registers[regId] == registers[regIdTw])
                        {
                            marker = command.Remove(1, 2).Replace('E', ':');
                            i = Array.IndexOf(_program, marker);
                        }
                        break;
                    case 'G':
                        regId = ((int)command[1]) - 97;
                        regIdTw = ((int)command[2]) - 97;
                        if (registers[regId] > registers[regIdTw])
                        {
                            marker = command.Remove(1, 2).Replace('G', ':');
                            i = Array.IndexOf(_program, marker);
                        }
                        break;
                    case 'Q':
                        return;
                        break;
                    default:
                        _put(ushort.Parse(command));
                        break;
                }

                i++;
            }
        }


    }


    class Qack
    {
        static void Main(string[] args)
        {
            QuackVm Vm = new QuackVm();

            //Vm.LoadProgram(new StreamReader("quack.in"));
            //Vm.Run(new StreamWriter("quack.out"));
            Vm.LoadProgram();
            Vm.Run();
        }
    }
}