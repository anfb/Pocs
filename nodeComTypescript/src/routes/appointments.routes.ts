import { Router } from 'express';
import { parseISO } from 'date-fns';
import AppointmentsRepository from '../repositories/AppointmentsRepository';
import CreateAppointmentService from '../services/CreateAppointmentService';

const appointmentsRouter = Router();
const appointmentsRepository = new AppointmentsRepository();

appointmentsRouter.post('/', (request, response) => {
  try {
    const { provider, date } = request.body;
    const parsedDate = parseISO(date);

    const createAppointmentService = new CreateAppointmentService(
      appointmentsRepository,
    );

    const appointment = createAppointmentService.execute({
      provider,
      date: parsedDate,
    });

    return response.json(appointment);
  } catch (e) {
    return response.status(400).json({ error: e.message });
  }
});

appointmentsRouter.get('/', (request, response) => {
  const findAllAppointments = appointmentsRepository.findAll();

  return response.json(findAllAppointments);
});

export default appointmentsRouter;
