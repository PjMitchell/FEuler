using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEuler
{
    public class NumberListFormatter
    {
        private List<int> _list;

        private string _result;

        public NumberListFormatter(IEnumerable<int> list)
        {
            _list = list.ToList();
            _list.Sort();
        }

        public string Get()
        {
            if (string.IsNullOrWhiteSpace(_result))
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    _result += _list[i];

                    if (_list.Count > i + 2 && _list[i] + 2 == _list[i + 2])
                    {
                        i = FindEnd(i + 2);
                    }
                    else
                    {
                        if (i + 1 < _list.Count)
                        {
                            _result += ", ";
                        }
                    }

                }

            }

            return _result;

        }

        private int FindEnd(int index)
        {
            if (_list.Count > index + 1 && _list[index] + 1 == _list[index + 1])
            {
                return FindEnd(index + 1);
            }
            else
            {
                string s = "-" + _list[index];
                _result += s;
                if (index + 1 < _list.Count)
                {
                    _result += ", ";
                }
                return index;
            }
        }
    }
}

