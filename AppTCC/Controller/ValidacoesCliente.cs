using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTCC.Controller
{
    public class ValidacoesCliente
    {

    }
    public class CNPJFormatterBehavior : Behavior<Entry>
    {
        private bool _ignoreEvent;

        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_ignoreEvent)
                return;

            var entry = (Entry)sender;
            string text = e.NewTextValue;
            string formattedText = FormatCNPJ(text);

            if (entry.Text != formattedText)
            {
                _ignoreEvent = true;
                entry.Text = formattedText;
                _ignoreEvent = false;
            }
        }

        private string FormatCNPJ(string cnpj)
        {
            cnpj = string.Join("", System.Text.RegularExpressions.Regex.Split(cnpj, @"[^\d]"));

            if (cnpj.Length > 14)
            {
                cnpj = cnpj.Substring(0, 14);
            }

            if (cnpj.Length > 2)
            {
                cnpj = $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2)}";
            }
            if (cnpj.Length > 6)
            {
                cnpj = $"{cnpj.Substring(0, 6)}.{cnpj.Substring(6)}";
            }
            if (cnpj.Length > 10)
            {
                cnpj = $"{cnpj.Substring(0, 10)}/{cnpj.Substring(10)}";
            }
            if (cnpj.Length > 15)
            {
                cnpj = $"{cnpj.Substring(0, 15)}-{cnpj.Substring(15)}";
            }

            return cnpj;
        }
    }

    public class EmailFormatterBehavior : Behavior<Entry>
    {
        private bool _ignoreEvent;

        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_ignoreEvent)
                return;

            var entry = (Entry)sender;
            string text = e.NewTextValue;
            string formattedText = FormatEmail(text);

            if (entry.Text != formattedText)
            {
                _ignoreEvent = true;
                entry.Text = formattedText;
                _ignoreEvent = false;
            }
        }

        private string FormatEmail(string email)
        {
            return email.ToLower(); // Formata para letras minúsculas (opcional)
        }
    }

    

    

}
